﻿using EhopV3.DtoLayer.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopV3.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            if (responseMessage.IsSuccessStatusCode) //200 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }
            return View();
        }
    }
}
