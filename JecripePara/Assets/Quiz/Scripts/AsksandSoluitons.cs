using UnityEngine;
using System.Collections;

public class AsksandSoluitons: MonoBehaviour{
	
	private string[] QuizAsk = new string[40];
	private string[] SolA = new string[40];
	private string[] SolB = new string[40];
	private string[] SolC = new string[40];
	private string[] SolD = new string[40];
	private string[] CorrectSol = new string[40];
	private int RandNumb;
	public bool i=false;

	public int RandomNumberfunction() {
		while (i==false) {
			RandNumb = Random.Range (0,40);
			i=true;
		}
		return RandNumb;
	}


	void Start(){
		QuizAsk [0] = "O esporte adaptado para pessoas deficientes surgiu:";
		QuizAsk [1] = "O esporte adaptado só teve início oficialmente:";
		QuizAsk [2] = "As primeiras competições em 1960 tiveram o apoio do Comitê Olímpico Italiano, e contou com a participação de 240 atletas de 23 países. Com o sucesso dos jogos o esporte se fortaleceu e foi fundada a:";
		QuizAsk [3] = "O primeiro ano de participação brasileira nos esportes adaptados foi:";
		QuizAsk [4] = "As primeiras medalhas do Brasil foram:";
		QuizAsk [5] = "Nos Estados Unidos, os Jogos foram dedicados para amputados, cegos e paralisados cerebrais, em relação a isso, é possível afirmar também que:";
		QuizAsk [6] = "As primeira Paralimpíadas de 1960 foram realizadas pelo(a):";
		QuizAsk [7] = "Nas Paralimpíadas de Londres, acreditava-se no destaque de Oscar Pistorius, mas um brasileiro acabou se destacando. Sobre Pistorius, é possível afirmar que o atleta:";
		QuizAsk [8] = "As Paralimpíadas foram organizadas pela primeira vez em 1960 na cidade de Roma. O evento foi realizado pelo(a):";
		QuizAsk [9] = "Os Jogos Paralímpicos de Londres, que deveriam se tornar o palco da consagração do sul-africano Oscar Pistorius, na verdade, destacaram um:";
		QuizAsk [10] = "Desde quando o atletismo é um esporte paralímpico?";
		//Athletics
		QuizAsk [11] = "As primeiras medalhas do Brasil nesta modalidade foi em:";
		QuizAsk [12] = "Os guias nas competições auxiliam de maneira que:";
		QuizAsk [13] = "O uso de equipamentos durante a competição tem:";
		QuizAsk [14] = "A avaliação para competições de atletismo é feita através de testes:";
		QuizAsk [15] = "As provas são dividas em:";
		QuizAsk [16] = "As provas de field e track são divididas de maneira que:";
		QuizAsk [17] = "O atleta Oscar Pistorius possui, no lugar das pernas, um par de:";
		QuizAsk [18] = "Os guias só começaram a subir no pódio junto com os atletas em:";
		QuizAsk [19] = "A Federação Internacional de Atletismo (IAAF) funciona como:";
		//Swimming
		QuizAsk [20] = "Quais são as modalidades tradicionais da natação?";
		QuizAsk [21] = "A FINA (Fédération Internacionale de Natation) define as largadas de modo que:";
		QuizAsk [22] = "O uso de próteses durantes as competições é:";
		QuizAsk [23] = "O Brasil começou a ganhar medalhas em:";
		QuizAsk [24] = "As classificações consistem em:";
		QuizAsk [25] = "O Que significa o S, SM e o SB, na natação?";
		QuizAsk [26] = "O Parapan do Rio de Janeiro (2007) foi caracterizado pela classificação geral cuja:";
		QuizAsk [27] = "A divisão das provas funciona de maneira que:";
		QuizAsk [28] = "A natação foi um dos oito esportes praticados nos primeiros Jogos Paralímpicos, em:";
		QuizAsk [29] = "A FINA(Fédération Internacionale de Natation) funciona como:";
		//Tennis
		QuizAsk [30] = "A origem do tênis em cadeira de rodas é:";
		QuizAsk [31] = "As primeiras cadeiras de rodas adaptadas para o esporte foram criadas em:";
		QuizAsk [32] = "A primeira exibição dos esporte como modalidade paraolímpica, em 1988, ocorreu em:";
		QuizAsk [33] = "A disputa paraolímpica do tênis de cadeiras de rodas foi oficializada, valendo medalhas pela primeira vez, no ano de:";
		QuizAsk [34] = "No Brasil, o primeiro atleta a ter contato com o tênis em cadeira de rodas foi:";
		QuizAsk [35] = "O único requisito para que uma pessoa possa competir em cadeira de rodas é:";
		QuizAsk [36] = "O primeiro campeonato norte-americano da modalidade ocorreu no ano de:";
		QuizAsk [37] = "A partir dos seus conhecimentos sobre José Morais, é possível afirmar que ele:";
		QuizAsk [38] = "É crescente participação de pessoas com deficiência nas modalidades e competições, mas:";
		QuizAsk [39] = "Uma pessoa que não têm deficiência pode estacionar em vagas de pessoas com deficiência?";
		
		//General
		SolA [0] = "na primeira década do século X.";
		SolA [1] = "Após as Olimpíadas de Atenas.";
		SolA [2] = "Federação Internacional de Atletismo.";
		SolA [3] = "1968.";
		SolA [4] = "Em 1976, na Paraolimpíadas do Canadá.";
		SolA [5] = "Robson Sampaio de Almeida e Luís Carlos 'Curtinho' conquistaram a prata na bocha.";
		SolA [6] = "Federação Internacional de Atletismo.";
		SolA [7] = "É ouro nos Jogos Parapan-americanos Rio 2007 e Guadalajara 2011, campeão mundial e eleito melhor atleta do mundo em 2010.";
		SolA [8] = "Federação Internacional de Atletismo.";
		SolA [9] = "Russo.";
		//Athletics
		SolA [10] = "Desde as Olimpíadas de Londres em 2012.";
		SolA [11] = "Nova York.";
		SolA [12] = "O atleta é direcionado para onde deve ir ou se deve acelerar ou não.";
		SolA [13] = "Como função de auxiliar aqueles que possui maior grau de deficiência em detrimento àqueles.";
		SolA [14] = "Muscular, de coordenação e funcional.";
		SolA [15] = "Corridas, arremesso, saltos e pentatlo.";
		SolA [16] = "Cadeirantes competem junto com deficientes visuais e cognitivos.";
		SolA [17] = "Pernas mecânicas automatizadas.";
		SolA [18] = "Nova York.";
		SolA [19] = "Investidor desses eventos paralímpicos.";
		//Swimming
		SolA [20] = "Costas, peito, borboleta e medley.";
		SolA [21] = "A largada pode ser feita pela plataforma de largada ou já dentro da piscina, de acordo com a preferência do atleta.";
		SolA [22] = "Próteses ou aparelhos de assistência são permitidos dentro da piscina.";
		SolA [23] = "Pittsburgh, Pensilvânia.";
		SolA [24] = "Um prefixo e um número. O primeiro indica o evento e o segundo mostra a categoria que o atleta disputa.";
		SolA [25] = "S: nado borboleta ou costas, SM: nado medley individual e SB: nado peito e livre.";
		SolA [26] = "Vitória do Brasil e os Estados Unidos ficou em segundo lugar.";
		SolA [27] = "Atletas com perda dos movimentos das pernas competem junto com deficientes visuais e auditivos.";
		SolA [28] = "Desde as Olimpíadas de Londres em 2012.";
		SolA [29] = "Investidor desses eventos paralímpicos.";
		//Tennis
		SolA [30] = "Inglesa.";
		SolA [31] = "1976 por Jeff Minnenbraker e Brad Parks.";
		SolA [32] = "Tokio.";
		SolA [33] = "1986.";
		SolA [34] = "José Carlos Morais.";
		SolA [35] = "Ter nascido com alguma má-formação física.";
		SolA [38] = "Não foi comprovado que esportes beneficiam pessoas com deficiência.";
		SolA [36] = "1976.";
		SolA [37] = "Conheceu o esporte em 1985, na Inglaterra, quando competia com a seleção de basquete em cadeira de rodas.";
		SolA [39] = "Sim, caso ela fique menos de 5 minutos.";
		
		//General
		SolB [0] = "na primeira década do século XV.";
		SolB [1] = "Após a Segunda Guerra Mundial, quando muitos soldados voltavam para casa mutilados.";
		SolB [2] = "Federação INternacional de natação.";
		SolB [3] = "1970.";
		SolB [4] = "Nos Jogos Parapanamericanos de Guadalajara em 2011.";
		SolB [5] = "A atleta Anaelise marcou sua presença, tornando-se a primeira cega brasileira medalhista do atletismo.";
		SolB [6] = "Comitê Paraolímpico Internacional.";
		SolB [7] = "É um nadador brasileiro, campeão olímpico de 50 metros livres nos Jogos Olímpicos de Pequim, em 2008.";
		SolB [8] = "Federação Mundial de Veteranos.";
		SolB [9] = "Brasileiro.";
		//Athletics
		SolB [10] = "Desde as Olimpíadas de Roma em 1960.";
		SolB [11] = "Londres.";
		SolB [12] = "O atleta troca de lugar com o guia no meio da competição, numa espécie de revezamento.";
		SolB [13] = "Como função de prevenir acidentes.";
		SolB [14] = "Funcional, muscular e tático.";
		SolB [15] = "Corridas, saltos, lançamentos e pentatlo.";
		SolB [16] = "Cadeirantes competem apenas com pessoas que também possuem deficiência nas pernas.";
		SolB [17] = "Lâminas.";
		SolB [18] = "Roma.";
		SolB [19] = "Órgão responsável, principalmente, por apresentar as normas e regras para esta modalidade, além de outras funções.";
		//Swimming
		SolB [20] = "Costas, peito, raso, medley.";
		SolB [21] = "Não há plataformas de largada opcionais, a largada precisa ser realizada dentro da piscina.";
		SolB [22] = "Próteses ou aparelhos de assistência são permitido em algumas divisões da modalidade.";
		SolB [23] = "Stoke Mandeville, Inglaterra.";
		SolB [24] = "Dois números. O primeiro indica o evento e o segundo mostra a categoria que o atleta disputa.";
		SolB [25] = "S: nado livre, borboleta ou costas, SM: nado medley com revezamento e individual e SB: nado peito.";
		SolB [26] = "Vitória do Canadá e o Brasil ficou em segundo lugar.";
		SolB [27] = "Atletas com problemas de coordenação nos quatro membros competem apenas com atletas com perda dos movimentos das pernas .";
		SolB [28] = "Desde as Olimpíadas de Roma em 1960.";
		SolB [29] = "Órgão responsável, principalmente, por apresentar as normas e regras para esta modalidade, além de outras funções.";
		//Tennis
		SolB [30] = "Alemã.";
		SolB [31] = "1976 pela Federação Internacional de Tênis em Cadeira de Rodas (IWTF).";
		SolB [32] = "Seul.";
		SolB [33] = "1988.";
		SolB [34] = "Oscar Pistorius.";
		SolB [35] = "Ter sido medicamente diagnosticada com uma deficiência relacionada a locomoção.";
		SolB [36] = "1978.";
		SolB [37] = "Em Seul, foi o primeiro brasileiro a representar o país na em basquete paralímpico, com Francisco Reis Junior.";
		SolB [38] = "O número de praticantes ainda é inexpressivo, se comparado à população que possui deficiência.";
		SolB [39] = "Sim, caso todas as outras vagas estejam ocupadas.";
		
		//General
		SolC [0] = "na primeira década do século XVIII.";
		SolC [1] = "Após as Olímpíadas de Roma.";
		SolC [2] = "Federação Internacional de Tênis em Cadeira de Rodas.";
		SolC [3] = "1972.";
		SolC [4] = " Nos Jogos Paralímpicos de Seul em 1988.";
		SolC [5] = "O time de basquete masculino em cadeira de rodas e um nadador, marcaram a presença do Brasil.";
		SolC [6] = "Federação Mundial de Veteranos.";
		SolC [7] = "É o primeiro atleta da história a competir de maneira simultânea com atletas não-deficientes, em nível mundial e olímpico.";
		SolC [8] = "Comitê Olímpico Internacional.";
		SolC [9] = "Alemão.";
		//Athletics
		SolC [10] = "Desde os Jogos Panamericanos em 2011.";
		SolC [11] = "Berlin.";
		SolC [12] = "O atleta é puxado pelo guia durante toda a competição.";
		SolC [13] = "Como função auxiliar sem apresentar vantagem durante a competição.";
		SolC [14] = "Tático, muscular e de coordenação.";
		SolC [15] = "Corridas, arremesso, salto com vara e pentatlo.";
		SolC [16] = "Tudo é muito bem divido de acordo com o grau de deficiência para que não haja vantagem ou desvantagem entre os atletas.";
		SolC [17] = "Placas de polietileno de alta performance.";
		SolC [18] = "Guadalajara.";
		SolC [19] = "Mediador entre os atletas paralímpicos e a população em geral dentro e fora das competições.";
		//Swimming
		SolC [20] = "Costas, revezamento, borboleta, medley.";
		SolC [21] = "Há uma espécie de escorregador que auxilia na largada de atletas que não possuem movimento das pernas.";
		SolC [22] = "Nenhuma prótese ou aparelho de assistência é permitido dentro da piscina.";
		SolC [23] = "Quito, Equador.";
		SolC [24] = "Duas letras. A primeiro indica o evento e a segundo mostra a categoria que o atleta disputa.";
		SolC [25] = "S: nado livre, borboleta ou costas, SM: nado medley individual e SB: nado peito.";
		SolC [26] = "Vitória dos Estados Unidos e o Brasil ficou em segundo lugar.";
		SolC [27] = "Atletas com mesmo nível de comprometimento competem juntos, para que não haja vantagem ou desvantagem entre os atletas.";
		SolC [28] = "Desde os Jogos Panamericanos em 2011.";
		SolC [29] = "Mediador entre os atletas paralímpicos e a população em geral dentro e fora das competições.";
		//Tennis
		SolC [30] = "Norte-americana.";
		SolC [31] = "1982 por Jeff Minnenbraker e Brad Parks.";
		SolC [32] = "Hong Kong.";
		SolC [33] = "1992.";
		SolC [34] = "Roger Federer.";
		SolC [35] = "Possuir algum tipo de prótese.";
		SolC [36] = "1980.";
		SolC [37] = "Conheceu o esporte em 1985, nos Estados Unidos, quando competia com a seleção de basquete em cadeira de rodas.";
		SolC [38] = "Os treinos preparatórios para o esporte ainda são muito caros para a maior parte da população.";
		SolC [39] = "Sim, essa separação é desnecessária e não é fiscalizada.";
		
		//General
		SolD [0] = "na primeira década do século XX.";
		SolD [1] = "Após a Primeira Guerra Mundial, quando muitos soldados voltavam para casa mutilados.";
		SolD [2] = "Federação Mundial de Veteranos.";
		SolD [3] = "1974.";
		SolD [4] = "Nos Jogos de Barcelona em 1992.";
		SolD [5] = "Nenhuma dessas alternativas.";
		SolD [6] = "Comitê Olímpico Internacional.";
		SolD [7] = "Nenhuma dessas alternativas.";
		SolD [8] = "Comitê Paralímpico Internacional.";
		SolD [9] = "Canadense.";
		//Athletics
		SolD [10] = "Desde as Olimpíadas de Atenas em 2004.";
		SolD [11] = "Roma.";
		SolD [12] = "Nenhuma dessas alternativas.";
		SolD [13] = "Nenhuma função, visto que são proibidos.";
		SolD [14] = "Apenas muscular.";
		SolD [15] = "Saltos, arremesso, maratona e pentatlo.";
		SolD [16] = "Os atletas podem escolher com quem querem competir.";
		SolD [17] = "Oscar Pistorius faz uso apenas cadeira de rodas.";
		SolD [18] = "Londres.";
		SolD [19] = "Nenhuma dessas alternativas.";
		//Swimming
		SolD [20] = "Raso, peito, borboleta, medley.";
		SolD [21] = "A largada precisa ser realizada a partir da plataforma de largada.";
		SolD [22] = "Próteses ou aparelhos de assistência são permitidos apenas nas Paralimpíadas.";
		SolD [23] = "Roma, Itália.";
		SolD [24] = "Nenhuma dessas alternativas.";
		SolD [25] = "S: nado livre ou costas, SM: nado medley com revezamento e SB: nado peito e borboleta.";
		SolD [26] = "Vitória do Brasil e o Canadá ficou em segundo lugar.";
		SolD [27] = "Os atletas podem escolher com quem querem competir.";
		SolD [28] = "Desde as Olimpíadas de Atenas em 2004.";
		SolD [29] = "Nenhuma dessas alternativas.";
		//Tennis
		SolD [30] = "Italiana.";
		SolD [31] = "1982 pela Federação Internacional de Tênis em Cadeira de Rodas (IWTF).";
		SolD [32] = "Singapura.";
		SolD [33] = "1990.";
		SolD [34] = "Novak Djokovic.";
		SolD [35] = "Possuir algum tipo de deficiência auditiva, cognitiva ou visual.";
		SolD [36] = "1982.";
		SolD [37] = "Em Atlanta, foi o segundo brasileiro a representar o país em basquete paralímpico, com Francisco Reis Junior.";
		SolD [38] = "Nenhuma dessas alternativas.";
		SolD [39] = "Não, em nenhuma situação.";
		
		//General
		CorrectSol [0] = "na primeira década do século XX.";
		CorrectSol [1] = "Após a Segunda Guerra Mundial, quando muitos soldados voltavam para casa mutilados.";
		CorrectSol [2] = "Federação Mundial de Veteranos.";
		CorrectSol [3] = "1972.";
		CorrectSol [4] = "Em 1976, na Paraolimpíadas do Canadá.";
		CorrectSol [5] = "A atleta Anaelise marcou sua presença, tornando-se a primeira cega brasileira medalhista do atletismo.";
		CorrectSol [6] = "Comitê Olímpico Internacional.";
		CorrectSol [7] = "É o primeiro atleta da história a competir de maneira simultânea com atletas não-deficientes, em nível mundial e olímpico.";
		CorrectSol [8] = "Comitê Olímpico Internacional.";
		CorrectSol [9] = "Brasileiro.";
		//Athletics
		CorrectSol [10] = "Desde as Olimpíadas de Roma em 1960.";
		CorrectSol [11] = "Nova York.";
		CorrectSol [12] = "O atleta é orientado sobre a direção que deve ir e se deve acelerar.";
		CorrectSol [13] = "Como função auxiliar sem apresentar vantagem durante a competição.";
		CorrectSol [14] = "Muscular, de coordenação e funcional.";
		CorrectSol [15] = "Corridas, saltos, lançamentos e pentatlo.";
		CorrectSol [16] = "Tudo é muito bem divido de acordo com o grau de deficiência para que não haja vantagem ou desvantagem entre os atletas.";
		CorrectSol [17] = "Lâminas.";
		CorrectSol [18] = "Guadalajara.";
		CorrectSol [19] = "Órgão responsável, principalmente, por apresentar as normas e regras para esta modalidade, além de outras funções.";
		//Swimming
		CorrectSol [20] = "Costas, peito, borboleta e medley.";
		CorrectSol [21] = "A largada pode ser feita pela plataforma de largada ou já dentro da piscina, de acordo com a preferência do atleta.";
		CorrectSol [22] = "Nenhuma prótese ou aparelho de assistência é permitido dentro da piscina.";
		CorrectSol [23] = "Stoke Mandeville, Inglaterra.";
		CorrectSol [24] = "Um prefixo e um número. O primeiro indica o evento e o segundo mostra a categoria que o atleta disputa.";
		CorrectSol [25] = "S: nado livre, borboleta ou costas, SM: nado medley individual e SB: nado peito.";
		CorrectSol [26] = "Vitória do Canadá e o Brasil ficou em segundo lugar.";
		CorrectSol [27] = "Atletas com mesmo nível de comprometimento competem juntos, para que não haja vantagem ou desvantagem entre os atletas.";
		CorrectSol [28] = "Desde as Olimpíadas de Roma em 1960.";
		CorrectSol [29] = "Órgão responsável, principalmente, por apresentar as normas e regras para esta modalidade, além de outras funções.";
		//Tennis
		CorrectSol [30] = "Norte-americana.";
		CorrectSol [31] = "1976 por Jeff Minnenbraker e Brad Parks.";
		CorrectSol [32] = "Seul.";
		CorrectSol [33] = "1992.";
		CorrectSol [34] = "José Carlos Morais.";
		CorrectSol [35] = "Ter sido medicamente diagnosticada com uma deficiência relacionada a locomoção.";
		CorrectSol [36] = "1980.";
		CorrectSol [37] = "Conheceu o esporte em 1985, na Inglaterra, quando competia com a seleção de basquete em cadeira de rodas.";
		CorrectSol [38] = "Número de praticantes ainda é inexpressivo se comparado à população que possui algum tipo de deficiência física.";
		CorrectSol [39] = "Não, em nenhuma situação.";

	}
	public string QuizQuestion(){
		return QuizAsk [RandomNumberfunction()];
	}
	public string QuizSolutionA(){
		return SolA [RandomNumberfunction ()];
	}
	public string QuizSolutionB(){
		return SolB [RandomNumberfunction ()];
	}
	public string QuizSolutionC(){
		return SolC [RandomNumberfunction ()];
	}
	public string QuizSolutionD(){
		return SolD [RandomNumberfunction ()];
	}
	public string QuizCorrectSol(){
		return CorrectSol [RandomNumberfunction ()];
	}
}
