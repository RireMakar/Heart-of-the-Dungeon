using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Heart_of_the_Dungeon
{
    class Mage : Hero
    {
        public Mage(Texture2D text, Rectangle rect, List<Wall> wallList)
            : base(text, rect, wallList)
        {
            name = "mage";
            damage = 1;
            health = 15;
            attackGrid = new AttackSpace[5, 5] {
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y - 64, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y - 64, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X, rectangle.Y - 64, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y - 64, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y - 64, 32, 32)),},  
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y - 32, 32, 32)), 
                                                 null, null, null,
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y - 32, 32, 32))},
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y, 32, 32)),
                                                 null, null, null,
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y, 32, 32))},
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y + 32, 32, 32)),
                                                 null, null, null,
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y + 32, 32, 32))},
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y + 64, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y + 64, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X, rectangle.Y + 64, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y + 64, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y + 64, 32, 32))}
                                                };
        }

        public override void UpdateAttackGrid()
        {
            attackGrid = new AttackSpace[5, 5] {
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y - 64, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y - 64, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X, rectangle.Y - 64, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y - 64, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y - 64, 32, 32)),},
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y - 32, 32, 32)), 
                                                 null, null, null,
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y - 32, 32, 32))},
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y, 32, 32)),
                                                 null, null, null,
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y, 32, 32))},
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y + 32, 32, 32)),
                                                 null, null, null,
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y + 32, 32, 32))},
                                                {new AttackSpace(new Rectangle(rectangle.X - 64, rectangle.Y + 64, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y + 64, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X, rectangle.Y + 64, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y + 64, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 64, rectangle.Y + 64, 32, 32))}
                                                };
        }
    }
}