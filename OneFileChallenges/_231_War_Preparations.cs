//231 War Preparations
Console.Title = "War Preparations";

Sword basicSword = new Sword(SwordMaterial.Iron, Gemstone.None, 20, 5f);
Sword superSword = basicSword with { Material = SwordMaterial.Binarium, Gemstone = Gemstone.Bitstone};
Sword upgradedBasic = basicSword with { Material = SwordMaterial.Steel, Gemstone = Gemstone.Emerald };

Console.WriteLine(basicSword);
Console.WriteLine(superSword);
Console.WriteLine(upgradedBasic);

record Sword(SwordMaterial Material, Gemstone Gemstone, float Length, float CrossguardWidth);

enum SwordMaterial { Wood, Bronze, Iron, Steel, Binarium}
enum Gemstone { None, Emerald, Amber, Sapphire, Diamont, Bitstone}