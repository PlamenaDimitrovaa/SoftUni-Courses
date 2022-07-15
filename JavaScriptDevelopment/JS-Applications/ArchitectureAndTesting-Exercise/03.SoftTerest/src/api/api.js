const host = 'http://localhost:3030';

async function request(method = 'get', url, data){

    const options = {
        method,
        headers: {}
    };

    const user = JSON.parse(localStorage.getItem('user'));
    if(user){
        const token = user.accessToken;
        options.headers['X-Authorization'] = token;
    }

    if(data != undefined){
        options['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    try {
        const response = await fetch(host + url, options);

        if(response.ok != true){
            if(response.status == 403){
                localStorage.removeItem('user');
            }
            
            const err = await response.json();
            throw new Error(err.message);
        }

        if(response.status == 204){
            return response;
        }else {
            return response.json();
        }

    } catch (error) {
        alert(error.message);
        throw error;
    }
}

const get = request.bind(null, 'get');
const post = request.bind(null, 'post');
const put = request.bind(null, 'put');
const del = request.bind(null, 'delete');

export {
    get,
    post,
    put, 
    del as delete
};
