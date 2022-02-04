<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

use App\Gamestate;
 
class GamestateController extends Controller
{
    public function index()
    {
        return Gamestate::all();
    }
 
    public function show(Gamestate $gamestate)
    {
        return $gamestate;
    }

    public function store(Request $request)
    {

        $gamestate = Gamestate::create($request->all());

        return response()->json($gamestate, 201);
    }

    public function update(Request $request, $gamestate)
    {

        $gamestate->update($request->all());

        return response()->json($gamestate, 200);
    }

    public function delete(Request $request, $id)
    {

        $gamestate->delete();

        return response()->json(null, 204);
    }
}