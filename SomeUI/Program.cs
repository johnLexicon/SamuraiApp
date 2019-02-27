using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context;

        static void Main(string[] args)
        {
            _context = new SamuraiContext();

            //_context.Add(new SamuraiBattle { SamuraiId = -1, BattleId = -3 });

            //EnlistSamuraiToBattle(-1, -1);

            Samurai samurai = GetSamuraiWithBattles(-1);

            foreach(var battle in samurai.GetBattles())
            {
                Console.WriteLine(battle.Name);
            }

            Console.WriteLine("I'm ready!!!");
        }

        //No need for SamuraiBattle DbSet.
        //You can use the Add method that is available directly in the context instance for Entitys without DbSet:s.
        static void AddSamuraiBattleEntity(SamuraiBattle samuraiBattle)
        {
            _context.Add(samuraiBattle);
            _context.SaveChanges();
        }


        static void EnlistSamuraiToBattle(int battleId,  int samuraiId)
        {
            Battle battle = _context.Battles.Find(battleId);
            if(battle != null)
            {
                battle.SamuraiBattles.Add(new SamuraiBattle { SamuraiId = samuraiId });
                _context.SaveChanges();
            }
        }

        static Samurai GetSamuraiWithBattles(int samuraiId)
        {
            return _context.Samurais
                .Include(s => s.SamuraiBattles)
                .ThenInclude(sb => sb.Battle) //Navigation through the Join entity.
                .FirstOrDefault(s => s.Id == samuraiId);
        }
    }
}
