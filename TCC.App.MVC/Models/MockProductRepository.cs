﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCC.App.MVC.Models
{
	public class MockProductRepository : IProductRepository
	{
		public List<Product> GetProducts()
		{
            var baseballCardGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var footballCardGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var basketballCardGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var hockeyCardGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            return new List<Product>() {
                new Product
            {
                ProductId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "John Egbert Live",
                Price = 65,
                // Player = "John Egbert",
                Year = DateTime.Now.AddMonths(6),
                // Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                CategoryId = baseballCardGuid
            },

            new Product
            {
                ProductId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "The State of Affairs: Michael Live!",
                Price = 85,
                // Player = "Michael Johnson",
                Year = DateTime.Now.AddMonths(9),
                // Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                CategoryId = baseballCardGuid
            },

            new Product
            {
                ProductId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Clash of the DJs",
                Price = 85,
                // Player = "DJ 'The Mike'",
                Year = DateTime.Now.AddMonths(4),
                // Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                CategoryId = baseballCardGuid
            },

            new Product
            {
                ProductId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                Name = "Spanish guitar hits with Manuel",
                Price = 25,
                // Player = "Manuel Santinonisi",
                Year = DateTime.Now.AddMonths(4),
                // Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                CategoryId = baseballCardGuid
            },

            new Product
            {
                ProductId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                Name = "Techorama 2021",
                Price = 400,
                // Player = "Many",
                Year = DateTime.Now.AddMonths(10),
                // Description = "The best tech conference in the world",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                CategoryId = hockeyCardGuid
            },
        };

		}
	}
}
