// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace EShopV3.IdentityServer
{
    public static class Config
    {   //Yetki-rol atamaları buradan ama ile 6. Core sürümünden sonrası için m-m Identity kurmak daha mantıklı 
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
             //ResourceCatalog keyine sahip olan kullanıcı CatalogFullPermission işlmini yapabilecek
            new ApiResource("ResourceCatalog"){ Scopes = {"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){ Scopes = {"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] //kullanıcı yetkileri ne yapabilir
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Read authorization included in catalog operations"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="EShopVisitorId",
                ClientName="EShop Visitor User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets ={new Secret("eshopsecret".Sha256())},
                AllowedScopes = { "DiscountFullPermission" }//Hangi yetkileri olacak
            },
            //Manager
            new Client()
            {
                ClientId="EShopShopManagerId",
                ClientName="EShop Manager User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets ={new Secret("eshopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission" }
            },
            //Admin
            new Client()
            {
                ClientId="EShopAdminId",
                ClientName="EShop Admin User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets ={new Secret("eshopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,

                },
                AccessTokenLifetime=600 //5 dk
            }

        };


    }
}