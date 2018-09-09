﻿using Rog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rog.Game
{
    public delegate CommandStateMutation CharacterCommandMutation(Character actor);
    public delegate StateMutation<ProgramState> CommandStateMutation(Command command);
    public class Character
    {
        public Item primaryArm;
        public List<Item> inventory = new List<Item>();

        public string name;
        public int hp;

        public (int x, int y) position;

        public CharacterType characterType;
        public Team team;
    }

    
    

}
