using ConsultantRuleConstructor.Data;
using Microsoft.EntityFrameworkCore;
using ConsultantRuleConstructor.Entities;
using ConsultantRuleConstructor.Interfaces;
using ConsultantRuleConstructor;

using var context = new AppDbContext();

 IUnitOfWork unitOfWork = new UnitOfWork(context);

IRuleConstructionService service = new RuleConstructionService(unitOfWork);


Console.WriteLine(context.Database.CanConnect());
context.Database.Migrate();
Console.WriteLine("Migration complete");


Organization organization = new Organization
{
    Name = "Фотостудия",
    Address = "Москва"
};

var document = new Document
{
    Name = "Фото",
    Organizations = { organization }
};

Guide guide = new Guide
{
    Message = "У вас имеется ИНН",
    Refuse = "Вам необходимо получить ИНН"
};

Profile profile = new Profile
{
    Status = true
};

var rule = new RuleBuilder()
    .SetName("Получение Фото")
    .SetDocument(document)
    .SetGuide(guide)
    .Build();

unitOfWork.Rules.Add(rule);
unitOfWork.Complete();

Console.WriteLine("Add rule");

var rules = unitOfWork.Rules.GetAll();

foreach(var r in rules)
{
    Console.WriteLine(r.Name);
}
