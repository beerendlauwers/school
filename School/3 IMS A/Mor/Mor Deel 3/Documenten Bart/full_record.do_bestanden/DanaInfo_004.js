function clear_years(){var B=document.forms[0];for(var A=0;A<DanaGetLength(B.year);A++){B.year[A].checked=false}return true}function set_period(A){document.forms[0].period[A].checked=true;return true}function select_week_button(A){if(!DanaGetLength(A)){A=0}document.forms[0].period[A].checked=true;return true}function select_year_button(A){try{if(!DanaGetLength(A)){A=1}document.forms[0].period[A].checked=true}catch(B){}return true}function select_year_range_button(A){if(!DanaGetLength(A)){A=2}document.forms[0].period[A].checked=true;return true}function check_start_and_end_years(A){if(!DanaGetLength(A)){A=2}if(document.forms[0].period[A].checked==true&&document.forms[0].startYear.value>document.forms[0].endYear.value){var B=document.forms[0].startYear.value;document.forms[0].startYear.value=document.forms[0].endYear.value;document.forms[0].endYear.value=B;return false}return true}function check_if_chem_selected(){for(var A=0;A<DanaGetLength(document.forms[0].chem_editions);A++){if(document.forms[0].chem_editions[A].checked==true){return 1}}return 0}function check_if_bib_selected(){for(var A=0;A<DanaGetLength(document.forms[0].editions);A++){if(document.forms[0].editions[A].checked==true){return 1}}return 0}function check_if_editions_selected(){for(var A=0;A<DanaGetLength(document.forms[0].editions);A++){if(document.forms[0].editions[A].checked==true){return 1}}for(var A=0;A<DanaGetLength(document.forms[0].fakeEditions);A++){if(document.forms[0].fakeEditions[A].checked==true){return 1}}return 0}function set_current_settings(G,C){try{var M=document.getElementById("db_timespan_current_settings");var A=new Array();var R;var F;var H=false;if(!document.getElementById("showLimits")){return false}if(document.forms[0].period[0].checked==true){var J=document.forms[0].range.selectedIndex;R=G+"="+document.forms[0].range[J].text;H=true}else{if(document.forms[0].period[1].checked==true){var E=document.forms[0].startYear.selectedIndex;var L=document.forms[0].endYear.selectedIndex;try{var D=document.forms[0].startYear[E].text;var S=document.forms[0].endYear[L].text;var I=document.forms[0].startYear[E].value-0;var B=document.forms[0].endYear[L].value-0;if(I<B){if(S.indexOf("-")!=-1){B=S.substring(S.indexOf("-")+1)-0}R=G+"="+I+"-"+B}else{if(I>B){if(D.indexOf("-")!=-1){I=D.substring(D.indexOf("-")+1)-0}R=G+"="+B+"-"+I}else{if(D.indexOf("-")!=-1){I=D}R=G+"="+I}}H=true}catch(Q){}}}if(H==true){A.push(R)}var O=new Array();var P=false;if(document.forms[0].fakeEditions!=null){for(var N=0;N<DanaGetLength(document.forms[0].fakeEditions);N++){if(document.forms[0].fakeEditions[N].checked==true){var K=document.forms[0].fakeEditions[N].value;var T=document.getElementById(K+"_name").value;O.push(T);P=true}}}else{if(document.forms[0].editions!=null){for(var N=0;N<DanaGetLength(document.forms[0].editions);N++){if(document.forms[0].editions[N].checked==true){var K=document.forms[0].editions[N].value;var T=document.getElementById(K+"_name").value;O.push(T);P=true}}}}if(P==true){F=C+"="+O.join("; ");A.push(F)}DanaPutInnerHTML(M,A.join(". <br>"),0)}catch(Q){return true}}function WCI_set_current_settings(L,K){try{var J=document.getElementById("db_timespan_current_settings");var H=new Array();var D;var G;var A=false;if(!document.getElementById("showLimits")){return false}if(document.forms[0].period[0].checked==true){var M=document.forms[0].range.selectedIndex;D=L+"="+document.forms[0].range[M].text;A=true}else{if(document.forms[0].period[1].checked==true){D=L+"="+document.forms[0].WCIEntDBvalue.value;A=true}}if(A==true){H.push(D)}var N=new Array();var C=false;if(document.forms[0].fakeEditions!=null){for(var E=0;E<DanaGetLength(document.forms[0].fakeEditions);E++){if(document.forms[0].fakeEditions[E].checked==true){var F=document.forms[0].fakeEditions[E].value;var B=document.getElementById(F+"_name").value;N.push(B);C=true}}}else{if(document.forms[0].editions!=null){for(var E=0;E<DanaGetLength(document.forms[0].editions);E++){if(document.forms[0].editions[E].checked==true){var F=document.forms[0].editions[E].value;var B=document.getElementById(F+"_name").value;N.push(B);C=true}}}}if(C==true){G=K+"="+N.join("; ");H.push(G)}DanaPutInnerHTML(J,H.join(". "),0)}catch(I){return true}};