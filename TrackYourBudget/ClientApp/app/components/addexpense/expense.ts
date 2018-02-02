export class Expense {
    categoryId: number;
    amount: number;
    date: Date;

    public constructor(init?: Partial<Expense>) {
        Object.assign(this, init);
    }
}