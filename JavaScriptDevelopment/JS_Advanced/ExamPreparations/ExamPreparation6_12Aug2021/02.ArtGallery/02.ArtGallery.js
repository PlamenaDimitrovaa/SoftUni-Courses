class ArtGallery{
    constructor(creator){
        this.creator = creator;
        this.possibleArticles = {
            "picture": 200,
            "photo": 50,
            "item": 250,
        }

        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity){
        articleModel = articleModel.toLowerCase();
        if(!this.possibleArticles.hasOwnProperty(articleModel)){
            throw new Error("This article model is not included in this gallery!");
        }

        
        let article = this.listOfArticles.find(x => x.articleName == articleName);
        if(article){
            article.quantity += quantity;
        } else{
            let currentArticle = {
                articleModel,
                articleName,
                quantity,
            }

            this.listOfArticles.push(currentArticle);
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality){
        if(this.guests.some(x => x.guestName == guestName)){
            throw new Error(`${guestName} has already been invited.`);
        } 

        let points = 0;

        if (personality === 'Vip') {
            points = 500;
        } else if (personality === 'Middle') {
            points = 250;
        } else {
            points = 50;
        }

        let guest = {
            guestName,
            points,
            purchaseArticle: 0
        }

        this.guests.push(guest);

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName){
        articleModel = articleModel.toLowerCase();
        let currentArticle = this.listOfArticles.find(x => x.articleModel == articleModel && x.articleName == articleName);
        if(!currentArticle || currentArticle.articleModel !== articleModel){
            throw new Error("This article is not found.");
        }

        if(currentArticle.quantity <= 0){
            return `The ${articleName} is not available.`;
        }

        if(!this.guests.some(x => x.guestName == guestName)){
            return "This guest is not invited.";
        }

        let guest = this.guests.find(g => g.guestName === guestName);

        if (guest.points < this.possibleArticles[currentArticle.articleModel]) {
            return `You need to more points to purchase the article.`;
        } else {
            guest.points -= this.possibleArticles[currentArticle.articleModel];
            guest.purchaseArticle++;
            currentArticle.quantity--;
        }

        return `${guestName} successfully purchased the article worth ${this.possibleArticles[currentArticle.articleModel]} points.`;
    }

    showGalleryInfo(criteria) {
        let result = [];

        if (criteria === 'article') {
            result.push('Articles information:');

            for (const article of this.listOfArticles) {
                result.push(`${article.articleModel} - ${article.articleName} - ${article.quantity}`);
            }
        } else if (criteria === 'guest') {
            result.push(`Guests information:`);

            for (const guest of this.guests) {
                result.push(`${guest.guestName} - ${guest.purchaseArticle}`);
            }
        }

        return result.join('\n');
    }
}