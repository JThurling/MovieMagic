export interface Movies {
  title: string;
  genre: string;
  price: number;
  orderId: string;
  id: string;
}

export interface OrderList {
  movies: Movies[];
  email: string;
  subtotal: number;
  id: string;
}


