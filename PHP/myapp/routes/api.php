<?php

use Illuminate\Http\Request;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::middleware('auth:api')->get('/user', function (Request $request) {
    return $request->user();
});

/*
Route::get('gamestates', function() {
    // If the Content-Type and Accept headers are set to 'application/json', 
    // this will return a JSON structure. This will be cleaned up later.
    return Gamestate::all();
});
 
Route::get('gamestates/{gamestate}', function($gamestate) {
    return Gamestate::find($gamestate);
});

Route::post('gamestates', function(Request $request) {
    return Gamestate::create($request->all);
});

Route::put('gamestates/{gamestate}', function(Request $request, $gamestate) {
    $gamestate = Gamestate::findOrFail($gamestate);
    $gamestate->update($request->all());

    return $gamestate;
});

Route::delete('gamestates/{gamestate}', function($gamestate) {
    Gamestate::find($gamestate)->delete();

    return 204;
});


Route::get('gamestates', 'GamestateController@index');
Route::get('gamestates/{gamestate}', 'GamestateController@show');
Route::post('gamestates', 'GamestateController@store');
Route::put('gamestates/{gamestate}', 'GamestateController@update');
Route::delete('gamestates/{gamestate}', 'GamestateController@delete');
*/

Route::get('gamesaves', 'GamesaveController@index');
Route::get('gamesaves/{saveId}', 'GamesaveController@show');
Route::post('gamesaves', 'GamesaveController@store');
Route::put('gamesaves/{gamesave}', 'GamesaveController@update');
Route::delete('gamesaves/{gamesave}', 'GamesaveController@delete');