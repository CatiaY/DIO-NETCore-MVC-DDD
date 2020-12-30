using CursoAPI.Controllers;
using CursoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CursoTest
{
    public class CategoriasControllerTest
    {
        // Cria objetos de Mock e não objetos reais
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

        public CategoriasControllerTest()
        {
            // Inicializa os objetos de teste
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { Id = 1, Descricao = "Teste Categoria" };

            // No mock, é necessário ensinar o comportamento dos métodos que serão utilizados, ou acusará erro
            
            // Indica que categorias dentro de mockContext é um mockSet
            _mockContext.Setup(m => m.Categorias).Returns(_mockSet.Object);

            // Indica o que cada método deve fazer
            _mockContext.Setup(m => m.Categorias.FindAsync(1)).ReturnsAsync(_categoria);            
            _mockContext.Setup(m => m.SetModified(_categoria));
            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);            
        }

        // Teste do GET BY ID
        [Fact]
        public async Task Get_Categoria()
        {
            // Cria uma nova instância da classe CategoriasController do projeto API passando o mock do context como parâmetro
            // Feito isso, todos os métodos dessa classe poderão ser acessados
            var service = new CategoriasController(_mockContext.Object);

            // Chama o método GetCategoria da classe CategoriasController passando um id qualquer
            var testCategoria = await service.GetCategoria(1);

            // Verifica se o método foi realmente chamado e se foi executado somente uma vez
            _mockSet.Verify(m => m.FindAsync(1), Times.Once());

            // Testa se o valor esperado é igual ao valor atual (esperado, atual)
            Assert.Equal(_categoria.Id, testCategoria.Value.Id);
        }
        

        [Fact]
        public async Task Put_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);
                        
            await service.PutCategoria(1, _categoria);

            // Verifica se o método foi realmente chamado e se foi executado somente uma vez
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());                        
        }


        [Fact]
        public async Task Post_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.PostCategoria(_categoria);

            // Verifica se o método foi realmente chamado e se foi executado somente uma vez
            _mockSet.Verify(Xunit => Xunit.Add(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }


        [Fact]
        public async Task Delete_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.DeleteCategoria(1);

            // Verifica se o método foi realmente chamado e se foi executado somente uma vez
            _mockSet.Verify(m => m.FindAsync(1), Times.Once());
            _mockSet.Verify(x => x.Remove(_categoria), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
