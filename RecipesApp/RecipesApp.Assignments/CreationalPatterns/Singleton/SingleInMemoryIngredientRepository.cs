﻿/*using RecipesApp.Application.Abstractions;
using RecipesApp.Domain.Models;

namespace RecipesApp.Assignments.CreationalPatterns.Singleton
{
    public class SingleInMemoryIngredientRepository : IIngredientRepository
    {
        private static SingleInMemoryIngredientRepository _ingredientRepository;
        private List<Ingredient> _ingredients = new();

        private SingleInMemoryIngredientRepository()
        {
            Console.WriteLine("Constructor called");
        }

        public static SingleInMemoryIngredientRepository Instance
        {
            get
            {
                Console.WriteLine("Instance called");
                if (_ingredientRepository == null)
                    _ingredientRepository = new SingleInMemoryIngredientRepository();

                return _ingredientRepository;
            }

            private set { }
        }

        public List<Ingredient> Ingredients => _ingredients;

        public void CreateIngredient(Ingredient ingredient)
        {
            ingredient.Id = _ingredients.Count + 1;
            _ingredients.Add(ingredient);
        }

        public void DeleteIngredient(int ingredientId)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            _ingredients.Remove(ingredient);
        }

        public Ingredient GetIngredientById(int ingredientId)
        {
            return _ingredients.FirstOrDefault(x => x.Id == ingredientId);
        }

        public Ingredient GetIngredientByName(string ingredientName)
        {
            return _ingredients.FirstOrDefault(x => x.Name == ingredientName);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return _ingredients;
        }

        public void UpdateIngredient(int ingredientId, Ingredient newIngredient)
        {
            var ingredient = _ingredients.FirstOrDefault(x => x.Id == ingredientId);
            var index = _ingredients.IndexOf(ingredient);
            newIngredient.Id = ingredientId;
            _ingredients[index] = newIngredient;
        }
    }
}
*/