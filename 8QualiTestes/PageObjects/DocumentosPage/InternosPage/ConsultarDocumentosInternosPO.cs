using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.DocumentosPage.InternosPage
{
    public class ConsultarDocumentosInternosPO : BasePage
    {

        public ConsultarDocumentosInternosPO acessarTelaConsultarDocumentos()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/Consultar");
            return this;
        }

        public void clicarDocumentoTabela(string titulo)
        {
            clicarBotao(By.XPath("//*[@title='" + titulo + "']"));
        }

        public void clicarBotaoRevisar()
        {
            aguarda_BotaoClicavel("botao-finalizar-modal");
        }

        public void preencherMotivoRevisao(string motivoRevisao)
        {
            escrever("MotivoRevisao", motivoRevisao);
        }

        public void aguardaMensagemRevisaoObrigatorio()
        {
            aguarda_ElementoPagina(By.XPath("//*[@id='erro']"));
        }

        public string getMensagemMotivoRevisaoObrigatorio()
        {
            
            return obterTexto(By.XPath("//*[@id='erro']"));
        }

    }
}
