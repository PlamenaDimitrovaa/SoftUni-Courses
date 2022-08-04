import { get, post, put, del } from './api.js';

export async function getAllOrphanages(){
    return get('/data/posts?sortBy=_createdOn%20desc');
}

export async function createPost(data){
    return post('/data/posts', data);
}

export async function getPostById(id){
    return get('/data/posts/' + id);
}

export async function deletePost(id){
    return del('/data/posts/' + id);
}

export async function editPost(id, data){
    return put('/data/posts/' + id, data);
}

export async function getMyPosts(userId){
    return get(`/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}