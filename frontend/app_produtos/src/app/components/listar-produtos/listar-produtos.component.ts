import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { error } from 'console';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ProdutosService } from 'src/app/services/produtos.service';

type MessageAlertType = { type: string; msg: string; timeout: number };


@Component({
  selector: 'app-listar-produtos',
  templateUrl: './listar-produtos.component.html',
  styleUrls: ['./listar-produtos.component.css']
})
export class ListarProdutosComponent implements OnInit {
  produtos: { id: number; nome: string; preco: number; quantidade: number; }[] = [];
  modalRef?: BsModalRef;
  produtoEditar: any;
  form: FormGroup = new FormGroup({});
  alert: MessageAlertType | undefined;
  constructor(private modalService: BsModalService, private produtosService: ProdutosService) {

  }

  ngOnInit(): void {
    this.listarTodosProdutos();
    this.initForm();

  }
  searchTerm: string = '';
  initForm() {
    this.form = new FormBuilder().group({
      id: [0,],
      nome: ['', Validators.required],
      preco: [0, [Validators.required, Validators.min(1)]],
      quantidade: [0, [Validators.required, Validators.min(1)]]
    });
  }
  listarTodosProdutos() {
    this.produtosService.buscarProdutos().subscribe((data: any) => {
      this.produtos = data;
    });

  }
  acaoIncluir() {
    debugger
    this.form.markAllAsTouched();
    if (this.form.invalid) {
      return;
    }
    const produto = this.form.value;
    if (produto.id === 0) {
      this.produtosService.salvarProduto(produto).subscribe(() => {
        this.alert = {
          type: 'success',
          msg: `Produto incluído com sucesso!`,
          timeout: 5000
        }
        this.listarTodosProdutos();
        this.modalRef?.hide();
      }, error => {
        this.alert = {
          type: 'danger',
          msg: `Erro ao incluir o produto!`,
          timeout: 5000
        }
        this.modalRef?.hide();
      });
    } else {
      this.produtosService.editarProduto(produto.id, produto).subscribe(() => {
        this.alert = {
          type: 'success',
          msg: `Produto editado com sucesso!`,
          timeout: 5000
        };
        this.listarTodosProdutos();
        this.modalRef?.hide();
      }, error => {
        this.alert = {
          type: 'danger',
          msg: `Erro ao editar o produto!`,
          timeout: 5000
        };
        this.modalRef?.hide();

      });
    }
    this.form.valid;
  }
  onClosed(): void {
    this.alert = undefined;
  }
  confirmarExclusao(id: number, template: TemplateRef<any>) {
    this.produtoEditar = this.produtos.find(p => p.id === id);
    this.openModal(template);
  }
  acaoExcluir(id: number) {

    this.produtosService.excluirProduto(id).subscribe(() => {
      this.alert = {
        type: 'success',
        msg: `Produto excluído com sucesso!`,
        timeout: 5000
      }
      this.modalRef?.hide();

      this.listarTodosProdutos();
    }, error => {
      this.alert = {
        type: 'danger',
        msg: `Erro ao excluir o produto!`,
        timeout: 5000
      }
      this.modalRef?.hide();

    });
  }
  acaoEditar(id: number, template: TemplateRef<any>) {
    debugger
    this.initForm();
    if (id === 0) {
      this.produtoEditar = { id: 0, nome: '', preco: 0, quantidade: 0 };
      this.openModal(template);
      return;
    }

    this.produtoEditar = this.produtos.find(p => p.id === id);

    if (!this.produtoEditar) {
      return;
    }
    this.form = new FormBuilder().group({
      id: [this.produtoEditar.id],
      nome: [this.produtoEditar.nome, Validators.required],
      preco: [this.produtoEditar.preco, [Validators.required, Validators.min(1)]],
      quantidade: [this.produtoEditar.quantidade, [Validators.required, Validators.min(1)]]
    });
    this.openModal(template);
  }
  limparPesquisa() {
    this.searchTerm = '';
    this.buscarProdutos();
  }
  buscarProdutos() {
    debugger
    if (!this.searchTerm || this.searchTerm.trim() === '') {
      this.produtosService.buscarProdutos().subscribe((data: any) => {
        this.produtos = data;
      });
      return;
    }
    this.produtos = this.produtos.filter(produto =>
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
