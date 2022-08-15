import { post, get, put, del } from './api.js';

export async function getAllPosts(){
    return get('/data/offers?sortBy=_createdOn%20desc');
}

export async function createPost(data){
    return post('/data/offers', data);
}

export async function getPostById(id){
    return get('/data/offers/' + id);
}

export async function deletePost(id){
    return del('/data/offers/' + id);
}

export async function editPost(id, data){
    return put('/data/offers/' + id, data);
}