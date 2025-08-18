export interface GamblerDataLayout {
    id?        : number  // ? indicates id is optional since the api will generate it when am pbject is stored
    address    : string
    name       : string
    birthDate  : string
    salary     : number
}