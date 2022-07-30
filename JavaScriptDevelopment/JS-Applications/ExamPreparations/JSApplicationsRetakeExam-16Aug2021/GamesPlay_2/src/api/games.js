import { get, post, del, put } from "./api.js";


export async function getRecent(){
    return get('/data/games?sortBy=_createdOn%20desc&distinct=category');
}

export async function getAllGames(){
    return get('/data/games?sortBy=_createdOn%20desc');
}

export async function createGame(data){
    return post('/data/games', data);
}

export async function getGameById(id){
    return get(`/data/games/${id}`);
}

export async function deleteById(id){
    return del(`/data/games/${id}`);
}

export async function editGame(id, data){
    return put(`/data/games/${id}`, data);
}