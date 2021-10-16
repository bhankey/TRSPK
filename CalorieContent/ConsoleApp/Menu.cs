using System;
using CalorieContent.Services.Ingredient;
using CalorieContent.Services.Recipe;

namespace ConsoleApp
{
    public class Menu
    {
        private readonly Business _business;
        private readonly DataIngredient _dataIngredient;
        private readonly DataRecipe _dataRecipe;

        public Menu(IRecipeService recipeService, IIngredientService ingredientService)
        {
            _business = new Business(recipeService);
            _dataIngredient = new DataIngredient(ingredientService);
            _dataRecipe = new DataRecipe(recipeService);
        }

        private void BusinessHandler()
        {
            Console.WriteLine("1) Детали о блюде");
            Console.WriteLine("2) Калорийностью ниже чем");
            Console.WriteLine("3) Блюда из ингредиентов");

            string line;
            var key = Console.ReadKey();
            char ch = key.KeyChar;
            Console.Clear();
            switch (ch)
            {
                case '1':
                    Console.WriteLine("Введите название блюда: ");
                    line = Console.ReadLine() ?? String.Empty;

                    Console.Clear();
                    Console.WriteLine(_business.RecipeDetails(line));
                    break;
                case '2':
                    Console.WriteLine("Введите каллорийность: ");
                    line = Console.ReadLine() ?? String.Empty;
                    Console.Clear();
                    try
                    {
                        var calorie = int.Parse(line);
                        Console.WriteLine(_business.RecipesCalorieLowerThan(calorie));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                    break;
                case '3':
                    Console.WriteLine("Через запятую введите игридиенты: ");
                    line = Console.ReadLine() ?? String.Empty;
                    Console.Clear();

                    Console.WriteLine(_business.RecipesConsistOf(line));
                    
                    break;
                default:
                    Console.WriteLine("Введена невалидная команда");
                    
                    break;
            }
        }

        private void DataIngredientHandler()
        {
            Console.WriteLine("1) Отображение одного элемента");
            Console.WriteLine("2) Отображение всех записей");
            Console.WriteLine("3) Редактирование записи");
            Console.WriteLine("4) Удаление записи");
            Console.WriteLine("5) Создание записи");
            string line;
            
            var key = Console.ReadKey();
            char ch = key.KeyChar;
            Console.Clear();
            switch (ch)
            {
                case '1':
                    Console.WriteLine("Введите название ингридиента: ");
                    line = Console.ReadLine() ?? String.Empty;

                    
                    Console.WriteLine(_dataIngredient.ShowOne(line));
                    
                    break;
                case '2':
                    Console.WriteLine(_dataIngredient.ShowAll());
                    
                    break;
                case '3':
                    Console.WriteLine("Введите название ингридиента: ");
                    var ingredient = Console.ReadLine() ?? String.Empty;
                    
                    Console.WriteLine("Введите каллорийность на 100 грамм: ");
                    var calorie = Console.ReadLine() ?? String.Empty;
                    

                    Console.WriteLine(_dataIngredient.Edit(ingredient, calorie));
                    
                    break;
                case '4':
                    Console.WriteLine("Удаление ингридиента: ");
                    line = Console.ReadLine() ?? String.Empty;

                    Console.WriteLine(_dataIngredient.Delete(line));
                    
                    break;
                case '5':
                    Console.WriteLine("Введите название ингридиента: ");
                    ingredient = Console.ReadLine() ?? String.Empty;
                    
                    Console.WriteLine("Введите каллорийность на 100 грамм: ");
                    calorie = Console.ReadLine() ?? String.Empty;
                    

                    Console.WriteLine(_dataIngredient.Edit(ingredient, calorie));
                    
                    break;
                default:
                    Console.WriteLine("Введена невалидная команда");
                    
                    break;
            }
        }

        private void DataRecipeHandler()
        {
            Console.WriteLine("1) Отображение одного элемента");
            Console.WriteLine("2) Отображение всех записей");
            Console.WriteLine("3) Редактирование записи");
            Console.WriteLine("4) Удаление записи");
            Console.WriteLine("5) Создание записи");
            string line;
            
            var key = Console.ReadKey();
            char ch = key.KeyChar;
            Console.Clear();
            switch (ch)
            {
                case '1':
                    Console.WriteLine("Введите название рецепта: ");
                    line = Console.ReadLine() ?? String.Empty;

                    
                    Console.WriteLine(_dataRecipe.ShowOne(line));
                    
                    break;
                case '2':
                    Console.WriteLine(_dataRecipe.ShowAll());
                    
                    break;
                case '3':
                    Console.WriteLine("Введите название рецепта: ");
                    var ingredient = Console.ReadLine() ?? String.Empty;
                    
                    Console.WriteLine("Введите название ингредиентов через запятую: ");
                    var calorie = Console.ReadLine() ?? String.Empty;
                    

                    Console.WriteLine(_dataRecipe.Edit(ingredient, calorie));
                    
                    break;
                case '4':
                    Console.WriteLine("Введите название рецепта: ");
                    line = Console.ReadLine() ?? String.Empty;

                    Console.WriteLine(_dataRecipe.Delete(line));
                    
                    break;
                case '5':
                    Console.WriteLine("Введите название рецепта: ");
                    ingredient = Console.ReadLine() ?? String.Empty;
                    
                    Console.WriteLine("Введите название ингредиентов через запятую: ");
                    calorie = Console.ReadLine() ?? String.Empty;
                    

                    Console.WriteLine(_dataRecipe.Edit(ingredient, calorie));
                    
                    break;
                default:
                    Console.WriteLine("Введена невалидная команда");
                    
                    break;
            }
        }

        public void Handle()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1) Работа с бизнес логикой");
                Console.WriteLine("2) Работа с данными об ингридиентах");
                Console.WriteLine("3) Работа с данными о рецептах");
                Console.WriteLine("Escape для выхода");

                var key = Console.ReadKey();
                char ch = key.KeyChar;
                Console.Clear();
                switch (ch)
                {
                    case '1':
                        BusinessHandler();

                        break;
                    case '2':
                        DataIngredientHandler();

                        break;
                    case '3':
                        DataRecipeHandler();

                        break;
                    default:
                        Console.WriteLine("Введена невалидная команда");

                        break;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}