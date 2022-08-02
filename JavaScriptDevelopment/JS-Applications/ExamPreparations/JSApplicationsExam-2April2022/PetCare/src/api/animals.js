import { get, post, put, del } from "./api.js";

export async function getAllAnimals(){
    return get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
}

export async function createAnimal(data){
    return post('/data/pets', data);
}

export async function getAnimalById(id){
    return get('/data/pets/' + id);
}

export async function deleteAnimalById(id){
    return del('/data/pets/' + id);
}

export async function editAnimal(id, data){
    return put('/data/pets/' + id, data);
}