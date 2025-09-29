import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { ShoppingCart } from "../models/shoppingcart";
import { catchError, map, of, tap } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class CartService {
  private readonly http = inject(HttpClient);
  private readonly baseURL = "/api/shoppingcart/";

  addBookToCart(userId: number, bookId: number) {
    return this.http.post<ShoppingCart[]>(
      this.baseURL + `addToCart/${userId}/${bookId}`,
      {}
    );
  }

  /*getCartItems(userId: number) {
    return this.http.get<ShoppingCart[]>(this.baseURL + userId);
  }*/
  getCartItems(userId: number) {
    return this.http.get<ShoppingCart[] | null>(this.baseURL + userId).pipe(
      // Log raw API response
      tap((response) => {
        console.log('Raw cart API response:', response);
      }),

      // Ensure we always return an array, even if null
      map((response) => response ?? []),

      // Log the transformed response (after null handling)
      tap((cartItems) => {
        console.log('Processed cart items:', cartItems);
      }),

      // Optional: handle errors gracefully
      catchError((error) => {
        console.error('Error fetching cart items:', error);
        return of([]); // return empty cart on error
      })
    );
  }

  // Delete a single item from the cart
  removeBookFromCart(userId: number, bookId: number) {
    return this.http.delete<ShoppingCart[]>(
      this.baseURL + `${userId}/${bookId}`,
      {}
    );
  }

  // Reduces the quantity by one for an item in shopping cart
  reduceCartQuantity(userId: number, bookId: number) {
    return this.http.put<ShoppingCart[]>(
      this.baseURL + `${userId}/${bookId}`,
      {}
    );
  }

  clearCart(userId: number) {
    return this.http.delete<number>(this.baseURL + `${userId}`, {});
  }
}
