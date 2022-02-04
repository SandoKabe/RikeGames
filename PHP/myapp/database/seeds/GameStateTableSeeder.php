<?php

use Illuminate\Database\Seeder;

class GameStateTableSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        // Let's truncate our existing records to start from scratch.
        Gamestate::truncate();

        $faker = \Faker\Factory::create();

        // And now, let's create a few articles in our database:
        for ($i = 0; $i < 50; $i++) {
            Gamestate::create([
                'saveId' => $faker->sentence,
                'score' => $faker->number,
                'lvlclick' => $faker->number,
                'lvlauto' => $faker->number,
                'seed' => $faker->number,
                'design' => $faker->sentence,
            ]);
        }
    }
}
