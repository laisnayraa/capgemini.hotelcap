using BoDi;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace HotelBDD.Steps
{
    [Binding]
    public class RoomStep
    {
        private string _host = "https://localhost:44334/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _id;
        private int _buildingFloor;
        private int _roomNum;
        private string _situation;
        private int _typeRoomId;

        public RoomStep(IObjectContainer objectContainer) => _objectContainer = objectContainer;

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

        [Given(@"que o endpoint do Room é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http do Room é '(.*)'")]
        public void DadoQueOMetodoHttpEh(string metodo)
        {
            if (metodo.ToUpper() == "GET")
                _restRequest.Method = Method.GET;

            if (metodo.ToUpper() == "POST")
                _restRequest.Method = Method.POST;

            if (metodo.ToUpper() == "PUT")
                _restRequest.Method = Method.PUT;

            if (metodo.ToUpper() == "PATCH")
                _restRequest.Method = Method.PATCH;

            if (metodo.ToUpper() == "DELETE")
                _restRequest.Method = Method.DELETE;
        }


        [Given(@"que o id é (.*)")]
        public void DadoQueOIdDoRoomEh(int id) => _id = id;

        [Given(@"que o andar é (.*)")]
        public void DadoQueOAndarEh(int buildingFloor) => _buildingFloor = buildingFloor;

        [Given(@"que o numero do Room é (.*)")]
        public void DadoQueONumerodoRoomEh(int roomNum) => _roomNum = roomNum;

        [Given(@"que a situation é (.*)")]
        public void DadoQueASituationEh(string situation) => _situation = situation;

        [Given(@"que o TypeRoom é (.*)")]
        public void DadoQueOTypeRoomEh(int typeRoomId) => _typeRoomId = typeRoomId;

        [When(@"obter o Room")]
        public void QuandoObterORoom() => GetRoom();

        [When(@"criar o Room")]
        public void QuandoCriarORoom() => CreateRoom();

        [When(@"atualizar o Room")]
        public void QuandoAtualizarORoom() => UpdateRoom();


        [Then(@"a resposta do Room será (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);

        public void CreateRoom()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                buildingFloor = _buildingFloor,
                roomNum = _roomNum,
                situation = _situation,
                typeRoomId = _typeRoomId
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }


        public void GetRoom()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if (_id != 0)
                _restRequest.AddParameter("id", _id);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void UpdateRoom()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                id = _id,
                situation = _situation
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

    }
}
