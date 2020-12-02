using BoDi;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace HotelBDD.Steps
{
    [Binding]
    public class OccupationStep
    {
        private string _host = "https://localhost:44334/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _dailyAmount;
        private DateTime _date;
        private int _clientId;
        private int _roomId;


        public OccupationStep(IObjectContainer objectContainer) => _objectContainer = objectContainer;

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

        [Given(@"que o endpoint é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http é '(.*)'")]
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


        [Given(@"que o dailyAmount é (.*)")]
        public void DadoQueAQtdeDiarysDaOcupacaoEh(int dailyAmount) => _dailyAmount = dailyAmount;

        [Given(@"que o date é (.*)")]
        public void DadoQueADataDaOcupacaoEh(DateTime date) => _date = date;

        [Given(@"que o client id é (.*)")]
        public void DadoQueOIdDoClienteDaOcupacaoEh(int clientId) => _clientId = clientId;

        [Given(@"que o room Id é (.*)")]
        public void DadoQueOIdDoQuartoDaOcupacaoEh(int roomId) => _roomId = roomId;

        [When(@"obter o occupation")]
        public void QuandoObterAOcupacao() => Occupation();


        [Then(@"a resposta será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);


        public void Occupation()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            _restRequest.AddJsonBody(new
            {
                DailyAmount = _dailyAmount,
                Date = _date,
                ClientId = _clientId,
                RoomId = _roomId
            });

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}
