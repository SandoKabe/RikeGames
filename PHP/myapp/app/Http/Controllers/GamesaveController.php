<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Gamesave;

class GamesaveController extends Controller
{
    public function index()
    {
        return Gamesave::all();
    }
 
    public function show($saveId)
    {
        //return Gamesave::find($id);

        $column = 'saveId'; // This is the name of the column you wish to search

        $savegame = Gamesave::where($column , '=', $saveId)->first();

        return $savegame ;

    }

    public function store(Request $request)
    {

        $gamesave = Gamesave::create($request->all());

        return response()->json($gamesave, 201);
    }

    public function update(Request $request, $gamesave)
    {

        $gamesave->update($request->all());

        return response()->json($gamesave, 200);
    }

    public function delete(Request $request, $id)
    {

        $gamesave->delete();

        return response()->json(null, 204);
    }
}
