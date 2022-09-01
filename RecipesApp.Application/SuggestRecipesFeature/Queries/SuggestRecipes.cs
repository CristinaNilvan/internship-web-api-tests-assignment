﻿using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.Queries
{
    public class SuggestRecipes : IRequest<List<Recipe>>
    {
        public string IngredientName { get; set; }
        public float IngredientQuantity { get; set; }
    }
}