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
    class Knight : Hero
    {
        // attributes
        

        public Knight(Texture2D text, Rectangle rect, List<Wall> wallList)
            : base(text, rect, wallList)
        {
            name = "knight";
            damage = 2;
            health = 25;
            attackGrid = new AttackSpace[5, 5] {  
                                                {null, null, null, null, null},
                                                {null, new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y - 32, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X, rectangle.Y - 32, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y - 32, 32, 32)), null}, 
                                                {null, new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y, 32, 32)),
                                                 null, 
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y, 32, 32)) , null},
                                                {null, new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y + 32, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X, rectangle.Y + 32, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y + 32, 32, 32)), null},
                                                {null, null, null, null, null}
                                                };
        }

        public override void UpdateAttackGrid()
        {
            attackGrid = new AttackSpace[5, 5] {  
                                                {null, null, null, null, null},
                                                {null, new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y - 32, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X, rectangle.Y - 32, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y - 32, 32, 32)), null}, 
                                                {null, new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y, 32, 32)),
                                                 null, 
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y, 32, 32)) , null},
                                                {null, new AttackSpace(new Rectangle(rectangle.X - 32, rectangle.Y + 32, 32, 32)), 
                                                 new AttackSpace(new Rectangle(rectangle.X, rectangle.Y + 32, 32, 32)),
                                                 new AttackSpace(new Rectangle(rectangle.X + 32, rectangle.Y + 32, 32, 32)), null},
                                                {null, null, null, null, null}
                                                };
        
        }
    }
}
