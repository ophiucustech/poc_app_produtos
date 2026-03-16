import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ProdutosService } from 'src/app/services/produtos.service';

@Component({
  selector: 'app-listar-produtos',
  templateUrl: './listar-produtos.component.html',
  styleUrls: ['./listar-produtos.component.css']
})
export class ListarProdutosComponent implements OnInit {
  produtos: { id: number; nome: string; preco: number; quantidade: number; }[] = [];
  modalRef?: BsModalRef;
  produtoEditar: any;
  constructor(private modalService: BsModalService, private produtosService: ProdutosService) {

  }

  ngOnInit(): void {
    this.produtos = this.listarTodosProdutos();

  }
  searchTerm: string = '';

  listarTodosProdutos() {
    const data = this.produtosService.buscarProdutos();
    return this.produtos;
       
  }

  acaoExcluir(id: number) {
    const result = confirm("Tem certeza que deseja excluir o produto com ID " + id + "?");

    if (result === true) {
      alert("Produto com ID " + id + " excluído com sucesso!");
    }
    else {
      alert("Exclusão do produto com ID " + id + " cancelada.");
    }
  }
  acaoEditar(id: number, template: TemplateRef<any>) {
    if( id === 0){
      this.produtoEditar = { id: 0, nome: '', preco: 0, quantidade: 0 };
      this.openModal(template);
      return;
    }
    
    this.produtoEditar = this.produtos.find(p => p.id === id);

    if (!this.produtoEditar) {
      alert("Produto com ID " + id + " não encontrado.");
      return;
    }
    this.openModal(template);
  }
  buscarProdutos() {
    this.produtos = this.listarTodosProdutos().filter(produto =>
      produto.nome.toLowerCase().includes(this.searchTerm.toLowerCase())
    );

    if (this.produtos.length === 0) {
      alert("Nenhum produto encontrado com o nome: " + this.searchTerm);
    }

  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
