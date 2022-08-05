import { get, post, put, del } from './api.js';

export async function getAllCars(){
    return get('/data/cars?sortBy=_createdOn%20desc');
}

export async function createCar(data){
    return post('/data/cars', data);
}

export async function getCarById(id){
    return get('/data/cars/' + id);
}

export async function deleteCar(id){
    return del('/data/cars/' + id);
}

export async function editCar(id, data){
    return put('/data/cars/' + id, data);
}

export async function getCarsByUserId(userId){
    return get(`/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function searchCar(query){
    return get(`/data/cars?where=year%3D${query}`);
}