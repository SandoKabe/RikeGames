<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Gamesave extends Model
{
    protected $fillable = ['id', 'saveId', 'score', 'lvlclick', 'lvlauto', 'seed', 'design'];
}
