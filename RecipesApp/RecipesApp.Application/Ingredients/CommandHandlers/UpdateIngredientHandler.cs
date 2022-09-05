﻿using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Ingredients.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Ingredients.CommandHandlers
{
    public class UpdateIngredientHandler : IRequestHandler<UpdateIngredient, Ingredient>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateIngredientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Ingredient> Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.Id, request.Name, request.Category, request.Calories, request.Fats,
                request.Carbs, request.Proteins);

            await _unitOfWork.IngredientRepository.Update(ingredient);
            await _unitOfWork.Save();

            return ingredient;
        }
    }
}
