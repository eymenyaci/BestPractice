using AutoMapper;
using BP.Api.Data.Models;
using BP.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BP.Api.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;

        public ContactService(IMapper Mapper,IHttpClientFactory HttpClientFactory)
        {
            mapper = Mapper;
            httpClientFactory = HttpClientFactory;
        }
        public ContactDVO GetContactById(int id)
        {
            Contact dbContact = getDummyContact();
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("garanti.com");
            //client.DefaultRequestHeaders.Add("Authorization", "Bearer 1231321231");
            //String get = await client.GetStringAsync("/api/getPayment");
            //client.Dispose();
            var client = httpClientFactory.CreateClient("garantiapi");
            ContactDVO resultContact = new ContactDVO();
            mapper.Map(dbContact, resultContact);
            return resultContact;
            
        }

        private Contact getDummyContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Eymen",
                LastName = "Yacı"
            };
        }
    }
}
