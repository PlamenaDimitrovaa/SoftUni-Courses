import { del, get, post, put } from "./api.js";

export async function getAllBooks(){
    return get('/data/books?sortBy=_createdOn%20desc');
}

export async function getBooksByUser(userId){
    return get(`/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function createBook(data){
    return post('/data/books', data);
}

export async function editBook(id, data){
    return put(`/data/books/${id}`, data);
}

export async function getBookById(id){
    return get(`/data/books/${id}`);
}

export async function deleteBookById(id){
    return del(`/data/books/${id}`);
}