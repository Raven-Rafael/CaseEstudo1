import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cadastro',
  standalone: false,
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent {
  cadastroForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient
  ) {
    this.cadastroForm = this.fb.group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmarSenha: ['', [Validators.required]]
    });
  }

  onSubmit(): void {
    if (this.cadastroForm.invalid) return;

    const { nome, email, senha, confirmarSenha } = this.cadastroForm.value;

    if (senha !== confirmarSenha) {
      alert('As senhas não coincidem!');
      return;
    }

    this.http.post('http://localhost:5093/api/usuario/registrar', {
      nome,
      email,
      senha
    }).subscribe({
      next: () => {
        alert('Cadastro realizado com sucesso!');
        this.cadastroForm.reset();
      },
      error: (err) => {
        console.error(err);
        alert('Erro ao cadastrar. Verifique os dados e tente novamente.');
      }
    });
  }
}
