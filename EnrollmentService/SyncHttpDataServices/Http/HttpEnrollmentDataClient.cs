﻿using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EnrollmentService.Dtos;
using Microsoft.Extensions.Configuration;


namespace EnrollmentService.SyncHttpDataServices.Http
{
    public class HttpEnrollmentDataClient : IEnrollmentDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public HttpEnrollmentDataClient()
        {
        }

        public HttpEnrollmentDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public async Task CreateEnrollmentFromPaymentService(EnrollmentCreateDto enrollment)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(enrollment),
                Encoding.UTF8, "application/json"
            );

            var response = await _httpClient.PostAsync(_configuration["PaymentService"], httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync Post to Command Service Success -->");
            }
            else
            {
                Console.WriteLine("--> Sync Post to Command Service Failed -->");
            }
        }
    }
}