//143 Simula`s Soup
Console.Title = "Simula`s Soup";

(Food food, Ingredient ingredient, Seasoning seasoning) userInput;
var soup = (food: Food.Soup, ingredient: Ingredient.Chicken, seasoning: Seasoning.Salty);
var specialSoup = (food: Food.Soup, ingredient: Ingredient.Carrots, seasoning: Seasoning.Sweet);
var stew = (food: Food.Stew, ingredient: Ingredient.Potatoes, seasoning: Seasoning.Spicy);
var gumbo = (food: Food.Gumbo, ingredient: Ingredient.Mushrooms, seasoning: Seasoning.Salty);

while (true)
{
    Console.WriteLine($"Food Recipes: \n" +
                  $"Classic soup: {soup.seasoning} {soup.ingredient} \n" +
                  $"Special soup: {specialSoup.seasoning} {specialSoup.ingredient}\n" +
                  $"Classic stew: {stew.seasoning} {stew.ingredient}\n" +
                  $"Classic gumbo: {gumbo.seasoning} {gumbo.ingredient}\n");
    Console.Write("0 - soup, 1 - stew, 2 - gumbo \n" +
                  "What food will you make? ");
    userInput.food = (Food)Convert.ToInt32(Console.ReadLine());

    Console.Write("0 - mushrooms, 1 - chicken, 2 - carrots, 3 - potatoes \n" +
                  "What ingredient will you put? ");
    userInput.ingredient = (Ingredient)Convert.ToInt32(Console.ReadLine());

    Console.Write("0 - spice, 1 - salt, 2 - sweet \n" +
                  "What seasoning will you put? ");
    userInput.seasoning = (Seasoning)Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("------------------------------------------\n" +
    (userInput == soup || userInput == specialSoup || userInput == stew || userInput == gumbo ?
    $"Congrats you made {userInput.seasoning} {userInput.ingredient} {userInput.food}!\n" :
    $"Ewww you made {userInput.seasoning} {userInput.ingredient} {userInput.food}. Retry ugh\n") +
    "------------------------------------------\n");
}

enum Food { Soup, Stew, Gumbo }
enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes }
enum Seasoning { Spicy, Salty, Sweet }