export interface ToDo{
    todoId: number;
    name: string;
    description: string;
    categories : {categoryId: number,
                name : string,
                description : string};
    priorities : {priorityId: number,
                name : string,
                description : string},
    users:{
            id:string;
           firstName:string;
            lastName:string;
    };
    userId:string;
    categoryId:number;
    priorityId:number;
    
}