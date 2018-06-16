using System;
using System.Collections.Generic;
using System.Text;

namespace Behold_the_watcher
{
    class LevelGenerator
    {
        private static Room GenericLevel()
        {
            Room hall = new Room();
            Room kitchen = new Room();
            Room store = new Room();
            kitchen.GetDwellers().Add(new Ezgara(new List<Item>(), 2, 2));
            store.GetDwellers().Add(new Jawler(new List<Item>(new Item[] { new Gulden() }), 3, 3));
            Room attic = new Room();
            Key key_to_the_kitchen = new Key();
            Gulden coin = new Gulden();
            Painting picture = new Painting(new List<Item>(new Item[] { coin }));
            Door door_to_the_kitchen = new Door(hall, kitchen, key_to_the_kitchen, Direction.FORWARD);
            Door stairs_to_the_attic = new Door(hall, attic, null, Direction.UPSTAIRS);
            Door door_to_the_store = new Door(kitchen, store, null, Direction.LEFT);
            Locker chest = new Locker(new List<Item>(new Item[] { key_to_the_kitchen }), null);
            attic.AddStaticActor(chest);
            kitchen.AddStaticActor(picture);
            return hall;
        }

        private static Func<Room> RandomLevel(int halls, int opponents)
        {

            return null;
        }

        public static Func<Room> GenericGenerator()
        {
            return () => LevelGenerator.GenericLevel();
        }

        public static Func<Dungeon,bool> GenericGoal()
        {
            return playground => playground.GetWanderer().GetLoot().FindAll(item => item is Gulden).Count >= 2;
        }
    }
}
