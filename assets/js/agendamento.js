console.log('agendamento.js carregado');
const form = document.querySelector('#form-agendamento');

form.addEventListener('submit', (event) => {
  event.preventDefault();
  console.log('submit interceptado, a página não recarregou');
});
const cpf = document.querySelector('#cpf');
const avisoCpf = document.querySelector('#aviso-cpf');

function validarCpf(campo, aviso) {
  const digitos = campo.value.replace(/\D/g, '');   // descarta ponto e traço
  const valido = digitos.length === 11;
  aviso.textContent = valido ? '' : 'O CPF precisa ter 11 dígitos.';
  campo.classList.toggle('campo-invalido', !valido);
  return valido;
}
function validarData(campo, aviso) {
  const hoje = new Date();
  hoje.setHours(0, 0, 0, 0);
  const escolhida = new Date(`${campo.value}T00:00:00`);   // evita o fuso UTC
  const valida = escolhida > hoje;
  aviso.textContent = valida ? '' : 'A consulta precisa ser em uma data futura.';
  return valida;
}

function validarHorario(campo, aviso) {
  const hora = Number(campo.value.split(':')[0]);
  const valida = hora >= 7 && hora < 19;
  aviso.textContent = valida ? '' : 'A Clínica Vida+ atende das 07h às 19h.';
  return valida;
}
const nome = document.querySelector('#nome');
const especialidade = document.querySelector('#especialidade');
const data = document.querySelector('#data');
const horario = document.querySelector('#horario');
const avisoData = document.querySelector('#aviso-data');
const avisoHorario = document.querySelector('#aviso-horario');
const resumo = document.querySelector('#resumo-agendamento');

form.addEventListener('submit', (event) => {
  event.preventDefault();

  const resultados = [
    validarCpf(cpf, avisoCpf),
    validarData(data, avisoData),
    validarHorario(horario, avisoHorario),
  ];
  if (resultados.includes(false)) return;   // alguma regra falhou

  resumo.textContent =
    `${nome.value} agendou ${especialidade.value} em ${data.value} às ${horario.value}.`;
  resumo.classList.remove('oculto');
});
const busca = document.querySelector('#busca-especialidade');
const cards = document.querySelectorAll('.lista-especialidades li');

busca.addEventListener('input', () => {
  const termo = busca.value.trim().toLowerCase();
  cards.forEach((card) => {
    const nome = card.textContent.toLowerCase();
    card.classList.toggle('oculto', !nome.includes(termo));
  });
});
