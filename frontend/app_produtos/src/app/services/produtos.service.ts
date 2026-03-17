import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProdutosService {

  urlBase = 'https://localhost:7204/api/produtos';
  constructor(private http: HttpClient) { }


  buscarProdutos() {
    return this.http.get(this.urlBase);
  }

  excluirProduto(id: number) {
    return this.http.delete(`${this.urlBase}/${id}`);
  }

  salvarProduto(produto: any) {
    if (produto.id === 0) {
      return this.http.post(this.urlBase, produto);
    } else {
      return this.http.put(`${this.urlBase}/${produto.id}`, produto);
    }
  }
  editarProduto(id: number, produto: any) {
    return this.http.put(`${this.urlBase}/${id}`, produto);
  }
  buscarProdutoPorId(id: number) {
    return this.http.get(`${this.urlBase}/${id}`);
  }

}
