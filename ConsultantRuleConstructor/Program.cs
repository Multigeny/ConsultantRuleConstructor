using ConsultantRuleConstructor.Data;
using Microsoft.EntityFrameworkCore;
using ConsultantRuleConstructor.Entities;
using ConsultantRuleConstructor.Interfaces;
using ConsultantRuleConstructor;



/*Console.WriteLine(context.Database.CanConnect());
context.Database.Migrate();
Console.WriteLine("Migration complete");
*/

using var context = new AppDbContext();

IUnitOfWork unitOfWork = new UnitOfWork(context);

IRuleConstructionService service =
    new RuleConstructionService(unitOfWork);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1. Создать правило");
    Console.WriteLine("2. Получить все правила");
    Console.WriteLine("3. Получить правило по Id");
    Console.WriteLine("0. Выход");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            CreateRule(service);
            break;

        case "2":
            ShowAllRules(service);
            break;

        case "3":
            ShowRuleById(service);
            break;

        case "0":
            return;
    }
}

static void CreateRule(
    IRuleConstructionService service)
{
    Console.Write("Название правила: ");
    var ruleName = Console.ReadLine();

    Console.Write("Название документа: ");
    var documentName = Console.ReadLine();

    Console.Write("Описание: ");
    var description = Console.ReadLine();

    Console.Write("Текст отказа: ");
    var refusal = Console.ReadLine();

    Console.Write("Название организации: ");
    var organizationName = Console.ReadLine();

    Console.Write("Адрес организации: ");
    var address = Console.ReadLine();

    Console.WriteLine("Статус пользователя ");
    var status = Console.ReadLine();
    


    var organization = new Organization
    {
        Name = organizationName ?? "",
        Address = address ?? ""
    };

    var document = new Document
    {
        Name = documentName ?? "",
        Organizations = new List<Organization>
        {
            organization
        }
    };

    var guide = new Guide
    {
        Message = description ?? "",
        Refuse = refusal ?? ""
    };

    var profile = new Profile
    {
        Status = status == "true"
    };


    var rule = new RuleBuilder()
            .SetName(ruleName ?? "")
            .SetDocument(document)
            .SetGuide(guide)
            .AddProfile(profile)
            .Build();


    var id = service.CreateRule(rule);

    Console.WriteLine();
    Console.WriteLine($"Создано правило #{id}");
}

static void ShowAllRules(
    IRuleConstructionService service)
{
    var rules = service.GetAllRules();

    foreach (var rule in rules)
    {
        Console.WriteLine();
        Console.WriteLine(
            $"{rule.Id} - {rule.Name}");
    }
}

static void ShowRuleById(
    IRuleConstructionService service)
{
    Console.Write("Введите Id: ");

    if (!int.TryParse(
        Console.ReadLine(),
        out int id))
    {
        return;
    }

    var rule = service.GetById(id);

    if (rule == null)
    {
        Console.WriteLine("Правило не найдено");
        return;
    }
    Console.WriteLine($"Id: {rule.Id}");
    Console.WriteLine($"Название {rule.Name}");
    
    Console.WriteLine($"Документ: {rule.Document.Name}");
        
    
    Console.WriteLine($"Описание правила: {rule.Guide.Message}");
    Console.WriteLine($"Описание отказа правила {rule.Guide.Refuse}"); 
    
    foreach (var organization in rule.Document.Organizations)
    {
        Console.WriteLine($"\t Организация: {organization.Name}");
        Console.WriteLine($"\t Адрес: {organization.Address}");
    }

}