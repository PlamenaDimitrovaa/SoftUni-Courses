import { get, post, put, del } from './api.js';

export async function getAllEvents(){
    return get('/data/theaters?sortBy=_createdOn%20desc&distinct=title');
}

export async function createEvent(data){
    return post('/data/theaters', data)
}

export async function getEventById(id){
    return get('/data/theaters/' + id);
}

export async function deleteEvent(id){
    return del('/data/theaters/' + id);
}

export async function editEvent(id, data){
    return put('/data/theaters/' + id, data);
}

export async function getEventsByUserId(userId){
    return get(`/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}