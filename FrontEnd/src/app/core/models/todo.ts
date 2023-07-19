export interface ToDo{
    id: number;
    name: string;
    description: string;
    categories : {categoryId: number,
                name : string,
                description : string};
    priorities : {priorityId: number,
                name : string,
                description : string}
    UserId:number
}