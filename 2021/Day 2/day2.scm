(load "read_input.scm")

; Abstraction barrier
(define input (read-lines "input.txt"))
(define (dir lst) (car lst))
(define (dist lst) (cadr lst))


; Main algorithm
(define (solver lst)
  (define (iter depth pos aim lst)
    (cond ((null? lst) (list (* depth pos) (* aim pos)))
          ((eq? 'up (dir lst))
           (iter (- depth (dist lst)) pos aim (cddr lst)))
          ((eq? 'down (dir lst))
           (iter (+ depth (dist lst)) pos aim (cddr lst)))
          (else
           (iter depth (+ pos (dist lst))
                 (+ aim (* depth (dist lst))) (cddr lst)))))
  (iter 0 0 0 lst))


; Tuple of part1 and part2
(solver input)