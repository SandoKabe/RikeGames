<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateGamestatesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('gamestate', function (Blueprint $table) {
            $table->increments('id');
            $table->string('saveId');
            $table->decimal('score');
            $table->decimal('lvlclick');
            $table->decimal('lvlauto');
            $table->integer('seed');
            $table->string('design');
            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('gamestate');
    }
}