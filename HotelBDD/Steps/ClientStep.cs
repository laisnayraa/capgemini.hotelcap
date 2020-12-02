using BoDi;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace HotelBDD.Steps
{
    [Binding]
    public class ClientStep
    {
        private string _host = "https://localhost:44334/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _id;
        private string _name;
        private string _cpf;
        private string _hashs;

        public ClientStep(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario]
        public void Setup()
        {
            _restClient = new RestClient();
            _objectContainer.RegisterInstanceAs(_restClient);
            _restRequest = new RestRequest();
            _objectContainer.RegisterInstanceAs(_restRequest);
            _restResponse = new RestResponse();
            _objectContainer.RegisterInstanceAs(_restResponse);
            _restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

        [Given(@"que o endpoint do Client é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http do Client é '(.*)'")]
        public void DadoQueOMetodoHttpEh(string metodo)
        {
            if (metodo.ToUpper() == "GET")
                _restRequest.Method = Method.GET;

            if (metodo.ToUpper() == "POST")
                _restRequest.Method = Method.POST;

            if (metodo.ToUpper() == "PUT")
                _restRequest.Method = Method.PUT;

            if (metodo.ToUpper() == "DELETE")
                _restRequest.Method = Method.DELETE;
        }


        [Given(@"que o id é (.*)")]
        public void DadoQueOIdDoClienteEh(int id) => _id = id;

        [Given(@"que o name é (.*)")]
        public void DadoQueONomeDoClienteEh(string name) => _name = name;

        [Given(@"que o CPF é (.*)")]
        public void DadoQueOCPFDoClienteEh(string cpf) => _cpf = cpf;

        [Given(@"que o hashs é (.*)")]
        public void DadoQueOHashDoClienteEh(string hashs) => _hashs = hashs;

        [When(@"obter o client")]
        public void QuandoObterOCliente() => Client();


        [Then(@"a resposta do Client será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);


        public void Client()
        {
            _restRequest.AddHeader("Content-Type", "application/json");
                
            if (_id != 0)
                    _restRequest.AddParameter("id", _id);
            else 
                _restRequest.AddJsonBody(new { Name = _name, CPF = _cpf, Hashs = _hashs });

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
