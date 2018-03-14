export class Expense {
    categoryId: number;
    amount: number;
    date: Date;
    description: string;

    public constructor(init?: Partial<Expense>) {
        Object.assign(this, init);
    }
}