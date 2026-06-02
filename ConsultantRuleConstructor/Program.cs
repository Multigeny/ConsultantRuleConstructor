using ConsultantRuleConstructor.Data;
using Microsoft.EntityFrameworkCore;
using ConsultantRuleConstructor.Entities;
using ConsultantRuleConstructor.Interfaces;
using ConsultantRuleConstructor;

using var context = new AppDbContext();

 IUnitOfWork unitOfWork = new UnitOfWork(context);

IRuleConstructionService service = new RuleConstructionService(unitOfWork);
/*
var organization = new Organization
{
    Name = "ФНС",
    Address = "Москва"
};

var guide = new Guide
{
    Message = "Обратитесь в ФНС",
    Refuse = "Получение невозможно без ИНН"
};

var document = new Document
{
    Name = "ИНН",
    Organizations = new List<Organization> { organization }
};

var condition = new Condition
{
    PropertyKey = "HasINN",
    Operator = "==",
    Value = "false"
};

var rule = new RuleBuilder()
    .SetName("Получение ИНН")
    .SetCondition(condition)
    .SetDocument(document)
    .SetGuide(guide)
    .Build();

var id = service.CreateRule(rule);
Console.WriteLine($"Rule Id = {id}");


var savedRule = service.GetById(id);
Console.WriteLine(savedRule?.Name);

var rules = service.GetAllRules();

foreach(var r in rules)
{
    Console.WriteLine($"{r.Id} {r.Name}");
}
*/

var profile = new Profile();
Console.Write("Есть ИНН? (true/false): ");

var hasINN = Console.ReadLine();

profile.profileProperties.Add(
    new ProfileProperties
    {
        Name = "HasINN",
        Value = hasINN ?? "false"
    });

Console.Write("Участник госпрограммы? (true/false): ");
var resettLementStatus = Console.ReadLine();

profile.profileProperties.Add
    (
        new ProfileProperties
        {
            Name = "ResettLementStatus",
            Value = resettLementStatus ?? "false"
        });

Console.Write("Есть сертификат? ");
var hasSertificate = Console.ReadLine();

profile.profileProperties.Add
    (
        new ProfileProperties
        {
            Name = "HasSertificate",
            Value = hasSertificate ?? "false"
        });









var evaluator = new RuleEvaluator();


var rules = service.GetAllRules();

var matchedRules = evaluator.Evaluate(profile, rules);

foreach (var rule in matchedRules)
{
    Console.WriteLine($"Правило: {rule.Name}");
    Console.WriteLine($"Отказ: {rule.Guide.Refuse}");
    Console.WriteLine($"Документ: {rule.Document.Name}");
}

