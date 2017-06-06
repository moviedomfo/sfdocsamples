
export interface IMovimiento{

    id:number;
    importe :number; 
    fecha:Date;    
    tipoId:number;
}

export class Movimiento implements IMovimiento{

    id:number;
    importe :number; 
    fecha:Date;    
    tipoId:number;
}