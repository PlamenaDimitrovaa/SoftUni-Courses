class Story {
    #comments;
    #likes;

    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this.#comments = [];
        this.#likes = [];
    }

    get likes() {
        if (this.#likes.length <= 0) {
            return `${this.title} has 0 likes`;
        } else if(this.#likes.length === 1) {
            return `${this.#likes[0]} likes this story!`;
        } else {
            return `${this.#likes[0]} and ${this.#likes.length - 1} others like this story!`;
        }
    }

    like(username) {
        if (this.#likes.includes(username)) {
            throw new Error("You can't like the same story twice!");
        } else if (username === this.creator) {
            throw new Error("You can't like your own story!");
        } else {
            this.#likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }

    dislike (username) {
        if (!this.#likes.includes(username)) {
            throw new Error(`You can't dislike this story!`);
        } else {
            this.#likes = this.#likes.filter(u => u !== username);

            return `${username} disliked ${this.title}`;
        }
    }

    comment (username, content, id) {
        let comment = {
            Id: id,
            Username: username,
            Content: content,
            Replies: []
        }

        let currComment = this.#comments.find(c => c.Id === id);

        if (currComment) {
            let replyId = Number(id + '.' + (currComment.Replies.length + 1));

            let reply = {
                Id: replyId,
                Username: username,
                Content: content,
            }

            currComment.Replies.push(reply);

            return 'You replied successfully';
        }

        comment.Id = this.#comments.length + 1;
        this.#comments.push(comment);

        return `${username} commented on ${this.title}`;
    }

    toString(sortingType) {
        const sortVersion = {
            asc: (a, b) => a.Id - b.Id,
            desc: (a, b) => b.Id - a.Id,
            username: (a, b) => a.Username.localeCompare(b.Username)
        }

        let comments = this.#comments.sort(sortVersion[sortingType]);
        comments.forEach(c => c.Replies.sort(sortVersion[sortingType]));

        let result = [];

        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this.#likes.length}`);
        result.push(`Comments:`);

        for (const comment of comments) {
            result.push(`-- ${comment.Id}. ${comment.Username}: ${comment.Content}`);

            for (const reply of comment.Replies) {
                result.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`);       
            }
        }
        return result.join('\n');
    }
}